import { Component, OnInit } from '@angular/core';
import {QuestionsService} from '../../Services/questions.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})

export class QuestionsComponent implements OnInit {

  question: any[];
  id: number;

  constructor(
    private questionService: QuestionsService,
  ) {}

  ngOnInit() {
    this.questionService.getOneQuestion(this.id);
    this.questionService.question.subscribe(
      (response) => {
        this.question = response;
      }
    );
  }
}
