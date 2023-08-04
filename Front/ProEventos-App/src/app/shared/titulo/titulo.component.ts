import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo: string = '';
  @Input() iconClass: string = 'fa fa-user';
  @Input() subtitulo: string = 'Meu subtitulo';
  @Input() botaoListar: boolean = false;

  constructor(private router: Router) {}

  public ngOnInit(): void {
  }

  public listar(): void{
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`])
  }

}
