import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Subject} from 'rxjs/Subject';

@Injectable()
export class QuestionsService {

  questions: any[];
  question = new Subject<any[]>();

  constructor(private client: HttpClient) { }

  getOneQuestion(id: number) {
    this.client.get<any[]>('http://localhost:54988/api/Questions/' + id)
      .subscribe(
        (response) => {
          this.questions = response;
          this.question.next(this.questions);
        },
        (error) => {
          alert('Erreur lors de la récupération de la question');
          console.error(error);
        }
      );
  }
}
