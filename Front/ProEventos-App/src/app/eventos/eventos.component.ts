import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  private eventos: any = [];
  public filteredEventos: any = [];
  private _filterList : string = "";
  widthImg: number = 150;
  marginImg: number = 2;
  showImg: boolean = true;
  

  public get filterList() : string {
    return this._filterList;
  }
  public set filterList(v : string) {
    this._filterList = v;
    this.filteredEventos = this._filterList ? this.filtrarEventos(this.filterList) : this.eventos;
  }
  
  filtrarEventos(dados: string): any{
    dados = dados.toLowerCase();
    return this.eventos.filter(
      (dado: any) =>
        dado.tema.toLocaleLowerCase().indexOf(dados) !== -1 ||
        dado.local.toLocaleLowerCase().indexOf(dados) !== -1 ||
        dado.dataEvento.toLocaleLowerCase().indexOf(dados) !== -1 ||
        dado.lote.toLocaleLowerCase().indexOf(dados) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  toggleImg(): void{
    this.showImg = !this.showImg;
  }

  public getEventos(): void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response,
        this.filteredEventos = this.eventos;
      },
      error => console.log(error)
    );
  }

}
