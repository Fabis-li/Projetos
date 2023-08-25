import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { IModule } from 'src/app/models/modules';
import { ITraining } from 'src/app/models/training';
import { TrainingService } from '../../../../services/training/training.service';
const YTPlayer = require('yt-player');
@Component({
  selector: 'pro-training-video',
  templateUrl: './training-video.component.html',
  styleUrls: ['./training-video.component.scss'],
})
export class TrainingVideoComponent implements OnInit {
  player: any;

  /*training: ITraining = {
    id: 1,
    url: 'https://certificadocursosonline.com/wp-content/uploads/2018/07/Curso-de-Manutenc%CC%A7a%CC%83o-de-Computadores.jpg',
    title: 'Curso de Manutenção de Computadores',
    description:
      'Architecto eaque consectetur nostrum impedit earum at harum. Reiciendis suscipit soluta, ab, repellat ad',
    teacher: 'Carlos Silva',
    duration: 20,
    active: true,
    date: new Date(2000 - 10 - 21),
    category: 'tecnologia',
    modules: [
      {
        moduleId: 1,
        titleModule: 'Módulo 1',
        link: 'vbs7jKRMuiA',
        img: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
        descriptionModule: 'Lorem ipsum dolor sit amet consectetur.',
        statusModule: 'finalizado',
      },
      {
        moduleId: 2,
        titleModule: 'Módulo 2',
        link: '3CC_YtyD7Po',
        img: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
        descriptionModule: 'Incidunt reiciendis vel asperiores.',
        statusModule: 'disponivel',
      },
      {
        moduleId: 3,
        titleModule: 'Módulo 3',
        link: 'TxxkFWty09g',
        img: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
        descriptionModule: 'Ullam, quisquam? Culpa doloremque.',
        statusModule: 'disponivel',
      },
    ],
  };*/

  constructor(private trainingService:TrainingService,
    private router:Router,
    private serviceTitle:Title) { }

  training!:ITraining | null;
  modules!:IModule[];
  
  ngOnInit(): void {
    this.serviceTitle.setTitle('NDD Training - Video');
    this.training =  this.trainingService.returnTraining();
    this.getModulesByTrainingId(this.training?.id);

    if(this.training == null)
      this.router.navigate(['home/trainings']);
  }

  getModulesByTrainingId(id:number){
    this.trainingService.getModulesByTrainingId(id)
    .subscribe((modules:IModule[]) => {
      this.modules = modules;
      this.callVideo(modules[0]);
    })
  }
  statusModuloCOmplete = true;


  callVideo(module:IModule){
    if(this.player){
      this.player.destroy();
    }

    this.player = new YTPlayer('#player', {
      timeupdateFrequency: 5000,
    });



    let progressBar: any;
    let idDinamico: any;
    let totalPorcent: number;
    let totalVideo: number;
    let tempoAtual: number;
    let porcent: number;
    let varAux: number;

    this.player.load(module?.link) // https://youtube.com/embed/
    this.player.setVolume(10)


    this.player.on('timeupdate', () => {

      progressBar = document.getElementById(module?.id.toString());
      idDinamico = document.getElementById(module?.link)

      totalPorcent = 100;
      totalVideo = Math.round(this.player.getDuration());
      tempoAtual = Math.round(this.player.getCurrentTime());
      porcent = Math.round((totalPorcent * tempoAtual) / totalVideo);

      varAux = progressBar.style.width.slice(
        0,
        progressBar.style.width.length - 1
      );

      if (varAux <= porcent && porcent <= 100) {
        progressBar.style.width = `${porcent}%`;
      }


      if(porcent > 94){
       idDinamico.style.visibility= 'hidden'
       //postCompletedModule()
      }
      if(porcent > 96){
       //getCompletedModuleByModuleId()

      }
    });

  }
}
