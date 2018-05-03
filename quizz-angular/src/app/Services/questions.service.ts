import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class QuestionsService {

  constructor(private client: HttpClient) { }

  getOneQuestion(id: number) {
    this.client.get<any[]>('http://localhost:54988/api/Questions/' + id)
      .subscribe(
        (response) => {
          return response;
        },
        (error) => {
          alert('Erreur lors de la récupération de la question');
          console.error(error);
        }
      );
  }
}
