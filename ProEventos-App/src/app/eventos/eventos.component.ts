import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
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
      (evento: {tema: string, local: string}) => evento.tema.toLocaleLowerCase().indexOf(filtroLista) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtroLista) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos() {

    this.http.get('https://localhost:7072/api/eventos').subscribe(
      response => {
        this.eventosFiltrados = this.eventos = response
      },
      error => console.log(error)
    );
  }
}
