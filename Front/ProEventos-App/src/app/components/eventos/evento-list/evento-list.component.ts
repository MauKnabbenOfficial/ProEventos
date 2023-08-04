import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';
import { TituloComponent } from 'src/app/shared/titulo/titulo.component';

@Component({
  selector: 'app-evento-list',
  templateUrl: './evento-list.component.html',
  styleUrls: ['./evento-list.component.scss']
})
export class EventoListComponent implements OnInit {

  private eventos: Evento[] = [];
  public filteredEventos: Evento[] = [];
  private _filterList : string = "";
  
  public widthImg = 150;
  public marginImg = 2;
  public showImg = true;
  
  modalRef?: BsModalRef;
  titulo?: TituloComponent;
  
  constructor(private eventoService: EventoService, private modalService: BsModalService, private toastr: ToastrService, private spinner: NgxSpinnerService, private router: Router) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public get filterList() : string {
    return this._filterList;
  }
  public set filterList(v : string) {
    this._filterList = v;
    this.filteredEventos = this._filterList ? this.filtrarEventos(this.filterList) : this.eventos;
  }
  
  public filtrarEventos(dados: string): Evento[]{
    dados = dados.toLowerCase();
    return this.eventos.filter(
      (dado: any) =>
        dado.tema.toLocaleLowerCase().indexOf(dados) !== -1 ||
        dado.local.toLocaleLowerCase().indexOf(dados) !== -1 ||
        dado.dataEvento.toLocaleLowerCase().indexOf(dados) !== -1 ||
        dado.lote.toLocaleLowerCase().indexOf(dados) !== -1
    )
  }

  public toggleImg(): void{
    this.showImg = !this.showImg;
  }

  public getEventos(): void{
    this.eventoService.getEventos().subscribe({
      next: (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.filteredEventos = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error("Não foi possivel carregar Eventos.", "ERRO!")
        console.log(error)
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {
    this.modalRef?.hide();
    this.showSuccess();
  }
 
  decline(): void {
    this.modalRef?.hide();
  }

  showSuccess() {
    this.toastr.success('O evento foi deletado com Sucesso.', 'Deletado!');
  }

  eventoDetails(id: number): void{
    this.router.navigate([`/eventos/detalhe/${id}`]);
  }

}
