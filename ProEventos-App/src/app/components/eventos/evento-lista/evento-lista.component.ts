import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  larguraImagem: number = 100;
  margemImagem: number = 2;
  exibirImagem: boolean = true;
  private _filtroLista: string = '';

  modalRef?: BsModalRef;

  public get filtroLista() {
    return this._filtroLista
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtroLista: string): Evento[] {
    filtroLista = filtroLista.toLocaleLowerCase();

    return this.eventos.filter(
      (evento: { tema: string, local: string }) => evento.tema.toLocaleLowerCase().indexOf(filtroLista) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtroLista) !== -1
    );
  }

  constructor(private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) { }

  ngOnInit() {

    this.spinner.show();
    this.getEventos();
    setTimeout(() => {
    }, 300);
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos() {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Falha ao carregar os Eventos.', 'Erro!')
      },
      complete: () => this.spinner.hide()
    });
  }

  public getEventosByTema(tema: string) {
    this.eventoService.getEventosByTema(tema).subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => console.log(error)
    });
  }

  public getEventoById(id: number) {
    this.eventoService.getEventosById(id).subscribe({
      next: (evento: Evento) => {
        this.eventos = [evento];
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => console.log(error)
    });
  }

  public openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public confirm(): void {
    this.modalRef?.hide();

    this.toastr.success('O Evento foi deletado com Sucesso','Deletado!')
  }

  public decline(): void {
    this.modalRef?.hide();
  }

  detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
