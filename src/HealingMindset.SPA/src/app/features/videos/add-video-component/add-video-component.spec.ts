import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVideoComponent } from './add-video-component';

describe('AddVideoComponent', () => {
  let component: AddVideoComponent;
  let fixture: ComponentFixture<AddVideoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddVideoComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AddVideoComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
