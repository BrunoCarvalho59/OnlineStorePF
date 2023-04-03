
import { Component, OnDestroy, OnInit } from '@angular/core';
import { combineLatest, EMPTY, map, Observable, of, Subscription } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { BasketItem } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit, OnDestroy {
    welcomeMessage$: Observable<string| null> = of(null);
    isGuest$!: Observable<boolean>;

    constructor(public basketService: BasketService, public accountService: AccountService) {}

    private subscription: Subscription = new Subscription();

    ngOnInit(): void {
      this.updateWelcomeMessage();
      
      const user$ = this.accountService.currentUser$;
      const guestId$ = this.getGuestId();

      this.subscription.add(
        this.accountService.guestLogin$.subscribe(() => {
          this.updateWelcomeMessage();
        })
      );
  }

    ngOnDestroy(): void {
      this.subscription.unsubscribe();
    }


    getCount(items: BasketItem[]) {
      return items.reduce((sum, item) => sum + item.quantidade, 0);
    }

    getGuestId(): Observable<string | null> {
      return new Observable((observer) => {
        const guestId = localStorage.getItem('guestId');
        observer.next(guestId);
        observer.complete();
      });
    }

    updateWelcomeMessage(): void {
      const user$ = this.accountService.currentUser$;
      const guestId$ = this.getGuestId();
      this.welcomeMessage$ = combineLatest([user$, guestId$]).pipe(
        map(([user, guestId]) => {
          if (user) {
            return `Bem-vindo ${user.displayNome}`;
          } else if (guestId) {
            return 'Bem-vindo convidado';
          } else {
            return '';
          }
        })
      );
    }


}
