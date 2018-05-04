import { Component, OnInit } from '@angular/core';
import {QuestionsService} from '../../Services/questions.service';
import {Observable} from 'rxjs/Observable';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})

export class QuestionsComponent implements OnInit {

  question: any[];

  constructor(
    private questionService: QuestionsService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.questionService.getOneQuestion(+id);
    this.questionService.question.subscribe(
      (response) => {
        this.question = response;
      }
    );
  }
}
