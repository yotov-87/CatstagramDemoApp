import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent {
  catForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private catService: CatService
  ) {
    this.catForm = this.formBuilder.group({
      'imageUrl':['', [Validators.required]],
      'description':['']
    });
   }

  create(){
    this.catService.create(this.catForm.value).subscribe(res => {
      console.log(res);
    });
  }

  get imageUrl() {
    return this.catForm.get('imageUrl');
  }

}
