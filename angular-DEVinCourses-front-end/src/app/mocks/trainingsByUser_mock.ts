import { ITraningByUser } from "../models/trainingByUser";


export const TRAININGBYUSER_MOCK: ITraningByUser[] = [
  {
      userId: 1,
      id: 2,
      url: 'https://setcesp.org.br/wp-content/uploads/2019/08/treinamento.jpg',
      title: 'Ingles Basico',
      description:
          'Neste curso, os alunos irão obter um conhecimento aprofundado sobre os recursos disponíveis sobre Inlges o basico.',
      teacher: 'Rodrigo Rosa',
      duration: 70,
      active: true,
      category: 'idioma',
      date:new Date(),
      modules:[
        {
          id: 1,
          trainingId:1,
          titleModule:'Módulo 1',
          link: 'vbs7jKRMuiA',
          image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
          descriptionModule: 'Lorem ipsum dolor sit amet consectetur.',
          statusModule: 'finalizado'
        },
        {
          id: 2,
          trainingId:1,
          titleModule:'Módulo 2',
          link: '3CC_YtyD7Po',
          image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
          descriptionModule: 'Incidunt reiciendis vel asperiores.',
          statusModule: 'disponivel'
        },
        {
          id: 3,
          trainingId:1,
          titleModule:'Módulo 3',
          link: 'TxxkFWty09g',
          image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
          descriptionModule: 'Ullam, quisquam? Culpa doloremque.',
          statusModule: 'disponivel'
        },
      ]
    },
  
{
        userId: 2,
        id: 1,
        url: 'https://certificadocursosonline.com/wp-content/uploads/2018/07/Curso-de-Manutenc%CC%A7a%CC%83o-de-Computadores.jpg',
        title: 'Manutenção de Computadores',
        description:
          'Architecto eaque consectetur nostrum impedit earum at harum. Reiciendis suscipit soluta, ab, repellat ad, Reiciendis suscipit soluta, ab, repellat ad',
        teacher: 'Carlos Silva',
        duration: 20,
        active: true,
        category: 'tecnologia',
        date:new Date(),
        modules:[
          {
            id: 1,
            trainingId:2,
            titleModule:'Módulo 1',
            link: 'vbs7jKRMuiA',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Lorem ipsum dolor sit amet consectetur.',
            statusModule: 'finalizado'
          },
          {
            id: 2,
            trainingId:2,
            titleModule:'Módulo 2',
            link: '3CC_YtyD7Po',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Incidunt reiciendis vel asperiores.',
            statusModule: 'disponivel'
          },
          {
            id: 3,
            trainingId:2,
            titleModule:'Módulo 3',
            link: 'TxxkFWty09g',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Ullam, quisquam? Culpa doloremque.',
            statusModule: 'disponivel'
          },
        ]
},

  {
        userId: 3,
        id: 16,
        url: 'https://certificadocursosonline.com/wp-content/uploads/2019/09/CAPA-DO-CURSO-DE-COACHING.jpg',
        title: ' Coaching',
        description:
          'Neste curso, os alunos irão obter um conhecimento aprofundado sobre os recursos disponíveis sobre Coaching.',
        teacher: 'Jair souza',
        duration: 16,
        active: true,
        category: 'psicologia',
        date:new Date(),
        modules:[
          {
            id: 1,
            trainingId:1,
            titleModule:'Módulo 1',
            link: 'vbs7jKRMuiA',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Lorem ipsum dolor sit amet consectetur.',
            statusModule: 'finalizado'
          },
          {
            id: 2,
            trainingId:1,
            titleModule:'Módulo 2',
            link: '3CC_YtyD7Po',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Incidunt reiciendis vel asperiores.',
            statusModule: 'disponivel'
          },
          {
            id: 3,
            trainingId:1,
            titleModule:'Módulo 3',
            link: 'TxxkFWty09g',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Ullam, quisquam? Culpa doloremque.',
            statusModule: 'disponivel'
          },
        ]
        },
{
        userId: 5,
        id: 18,
        url: 'https://www.redeicm.org.br/purissimo/wp-content/uploads/sites/16/2019/10/Como-escrever-uma-reda%C3%A7%C3%A3o-nota-mil-1024x1009.jpg',
        title: ' Redacao',
        description:
          'Neste curso, os alunos irão obter um conhecimento aprofundado sobre os recursos disponíveis .',
        teacher: 'Maria Eduarda',
        duration: 18,
        active: true,
        category: 'educacao',
        date:new Date(),
        modules:[
          {
            id: 1,
            trainingId:1,
            titleModule:'Módulo 1',
            link: 'vbs7jKRMuiA',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Lorem ipsum dolor sit amet consectetur.',
            statusModule: 'finalizado'
          },
          {
            id: 2,
            trainingId:1,
            titleModule:'Módulo 2',
            link: '3CC_YtyD7Po',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Incidunt reiciendis vel asperiores.',
            statusModule: 'disponivel'
          },
          {
            id: 3,
            trainingId:1,
            titleModule:'Módulo 3',
            link: 'TxxkFWty09g',
            image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU',
            descriptionModule: 'Ullam, quisquam? Culpa doloremque.',
            statusModule: 'disponivel'
          },
        ]
}

];
