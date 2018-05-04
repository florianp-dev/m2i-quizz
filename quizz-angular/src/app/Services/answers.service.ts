import {Injectable, OnInit} from '@angular/core';
import {Subject} from 'rxjs/Subject';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class AnswersService {
  answers: any[];
  answer = new Subject();

  constructor(private client: HttpClient) { }

  getAnswersForQuestion(id: number) {
    this.client.get<any[]>('http://localhost:54988/api/Answers/' + id)
      .subscribe(
        (response) => {
          this.answers = response;
          this.answer.next(this.answers);
        },
        (error) => {
          alert('Erreur lors de la récupération de la question');
          console.error(error);
        }
      );
  }
}
