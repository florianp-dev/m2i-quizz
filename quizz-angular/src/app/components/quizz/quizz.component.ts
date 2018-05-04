import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {AnswersService} from '../../Services/answers.service';

@Component({
  selector: 'app-quizz',
  templateUrl: './quizz.component.html',
  styleUrls: ['./quizz.component.scss']
})

export class QuizzComponent implements OnInit {
  id: number;
  answers: any;

  constructor(
    private route: ActivatedRoute,
    private answerService: AnswersService
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.answerService.getAnswersForQuestion(this.id);
    this.answerService.answer.subscribe(
      (response) => {
        this.answers = response;
      }
    );
  }
}
