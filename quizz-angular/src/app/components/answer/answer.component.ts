import { Component, OnInit } from '@angular/core';
import {AnswersService} from '../../Services/answers.service';

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.scss']
})
export class AnswerComponent implements OnInit {

  constructor(private AnswerService: AnswersService) { }

  ngOnInit() {
  }
}
