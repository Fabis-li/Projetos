import { Component, Input, OnInit } from '@angular/core';
import { ITraining } from 'src/app/models/training';

@Component({
  selector: 'pro-item-training',
  templateUrl: './item-training.component.html',
  styleUrls: ['./item-training.component.scss'],
})
export class ItemTrainingComponent implements OnInit {
  
  @Input()
  item: ITraining = {
    id: 0,
    url: '',
    title: '',
    description: '',
    teacher: '',
    duration: 0,
    active: true,
    category: '',
    date: new Date(),
    modules:[]
  };
  
  formatarDuracao(duracao:number):any{
    return duracao.toString().replace(':00:00', '')
  }

  constructor() {}

  ngOnInit(): void {}
}
