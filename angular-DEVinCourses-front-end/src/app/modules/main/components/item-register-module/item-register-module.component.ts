import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'pro-item-register-module',
  templateUrl: './item-register-module.component.html',
  styleUrls: ['./item-register-module.component.scss'],
})
export class ItemRegisterModuleComponent implements OnInit {
  formModule: FormGroup = new FormGroup({});

  constructor(private formbuilder: FormBuilder) {
    this.formModule = formbuilder.group({
      titleModule: ['', [Validators.required]],
      img: ['', [Validators.required]],
      descriptionModule: ['', [Validators.required]],
      link: [
        '',
        // Validators.required,
        Validators.pattern('^(https?://)?(www.youtube.com|youtu.be)/.+$'),
      ],
    });
  }

  ngOnInit(): void {}
  ShowData() {
    console.log(this.formModule);
    debugger;
    this.formModule.reset();
  }
  ResetForm() {
    this.formModule.reset();
  }

  onChange(event: any) {
    console.log(event);
    const selectedFiles = <FileList>event.srcElement.files;
    //document.getElementById('customFileLabel').innerHTML =
    selectedFiles[0].name;
  }
}
