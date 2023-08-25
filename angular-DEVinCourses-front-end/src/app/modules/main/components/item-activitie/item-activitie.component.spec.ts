import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActivitieComponent } from './item-activitie.component';

describe('ItemActivitieComponent', () => {
  let component: ItemActivitieComponent;
  let fixture: ComponentFixture<ItemActivitieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActivitieComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActivitieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
