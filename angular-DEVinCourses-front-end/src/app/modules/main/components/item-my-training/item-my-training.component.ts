import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ITraining } from 'src/app/models/training';
import { AlertService } from '../../services/alert/alert.service';
import { TrainingService } from '../../../../services/training/training.service';

@Component({
  selector: 'pro-item-my-training',
  templateUrl: './item-my-training.component.html',
  styleUrls: ['./item-my-training.component.scss'],
})
export class ItemMyTrainingComponent implements OnInit {
  userId!: number;

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
    modules: [],
  };

  constructor(
    private alertService: AlertService,
    private trainingService: TrainingService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  removeTraining() {
    this.alertService.alertDeleteTraining();
  }

  selectTraining(training: ITraining) {
    this.trainingService.training = training;
    this.router.navigate(['home/video']);
    this.refreshRecentTraining(1, Date.now());
  }

  refreshRecentTraining(id: number, dateRefresh: number) {
    this.trainingService.PatchRecentTrainingsByUser(id, dateRefresh);
  }

  formatarDuracao(duracao:number):any{
    return duracao.toString().replace(':00:00', '')
  }
}
