import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, map, Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User, Morada } from '../shared/models/user';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  welcomeMessage$ = new Subject<string>();
  guestLogin$ = new Subject<void>();

  constructor(private http: HttpClient, private router: Router) {  }

  loadCurrentUser(token:string) {
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<User>(this.baseUrl + 'account', {headers}).pipe(
      map(user => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        return user;
      })
    )
  }

  login(values: any){
    return this.http.post<User>(this.baseUrl + 'account/login', values).pipe(
      map(user => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        return user; //Voltar aqui 194
      })
    )
  }

  registo(values: any){
    return this.http.post<User>(this.baseUrl + 'account/registo', values).pipe(
      map(user => {
        if (user) {localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);}
      })
    )
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('guestId');
    this.currentUserSource.next(null);
    this.welcomeMessage$.next('');
    this.router.navigateByUrl('/');
    this.guestLogin$.next();
  }

  checkEmailExists(email: string) {
    return this.http.get<boolean>(this.baseUrl + 'account/emailexiste?email=' + email);
  }

  isGuest(): Observable<boolean> {
    return this.currentUser$.pipe(
      map(user => user === null && localStorage.getItem('guestId') !== null)
    );
  }

  getUserMorada() {
    return this.http.get<Morada>(this.baseUrl + 'account/morada');
  }

  updateUserMorada(morada: Morada) {
    return this.http.put(this.baseUrl + 'account/morada', morada);
  }

  /*updateRoles(role: User) {
    return this.http.put(this.baseUrl + 'account/role', role);
  } //ideia para alterar os roles */
}
