import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  @Input() titulo?: string;
  @Input()iconClass: string = 'fa fa-circle-xmark';
  @Input()subtitulo: string = 'Desde 2023';
  @Input()utilizaLista: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
