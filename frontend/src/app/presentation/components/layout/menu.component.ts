import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { MenuItemComponent } from './menu-item.component';

@Component({
    selector: 'app-menu',
    standalone: true,
    imports: [CommonModule, MenuItemComponent, RouterModule],
    template: `
        <ul class="layout-menu">
            @for (item of model; track $index; let i = $index) {
                @if (item.separator) {
                    <li class="menu-separator"></li>
                } @else {
                    <li app-menuitem [item]="item" [index]="i" [root]="true"></li>
                }
            }
        </ul>
    `
})
export class MenuComponent {
    model: MenuItem[] = [];

    ngOnInit() {
        this.model = [
            {
                label: 'Home',
                items: [{ label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] }]
            }
        ];
    }
}
