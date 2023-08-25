import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemRegisterModuleComponent } from './item-register-module.component';

describe('ItemRegisterModuleComponent', () => {
  let component: ItemRegisterModuleComponent;
  let fixture: ComponentFixture<ItemRegisterModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemRegisterModuleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemRegisterModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
