import { Component, OnInit } from '@angular/core';
import {QuestionsService} from '../../Services/questions.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})

export class QuestionsComponent implements OnInit {

  question: any[];

  constructor(private questionService: QuestionsService) { }

  ngOnInit() {
    this.question = this.questionService.getOneQuestion(1);
  }
}
