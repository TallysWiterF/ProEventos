import { Component, OnInit } from '@angular/core';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  providers: [EventoService]
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  larguraImagem: number = 100;
  margemImagem: number = 2;
  exibirImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtroLista: string): any {
    filtroLista = filtroLista.toLocaleLowerCase();

    return this.eventos.filter(
      (evento: { tema: string, local: string }) => evento.tema.toLocaleLowerCase().indexOf(filtroLista) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtroLista) !== -1
    );
  }

  constructor(private eventoService: EventoService) { }

  ngOnInit() {
    this.getEventos();
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos() {
    this.eventoService.getEventos().subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }
}
