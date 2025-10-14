import { computed, Directive, ElementRef, inject, OnInit, signal } from "@angular/core";
import { BookableResourceService } from '@/features/floorplan/services/bookable-resource.service';

@Directive({
    selector: '[data-component="DESK"]',
    host: {
        '[class]': 'cssClasses()',
        '(click)': 'onDeskClicked()'
    }
})
export class DeskResourceDirective implements OnInit {
    private readonly _elementRef = inject(ElementRef<SVGElement>);
    private readonly _bookableResouceService = inject(BookableResourceService);
    private readonly _resourceIdFromElement = signal<string>('');
    private readonly _resourceTypeFromElement = signal<string>('');

    desk = computed(() => this._bookableResouceService.getResourceById(this._resourceIdFromElement())());
    cssClasses = computed(() => {
        const result: {[x: string]: boolean} = { 'desk': true };
        if (this._resourceTypeFromElement()) {
            result[`desk--${this._resourceTypeFromElement()}`] = true;
        }
        return result;
    });

    ngOnInit() {
        this.extractInformationFromElement();
    }

    onDeskClicked() {
        this._bookableResouceService.selectResource(this._resourceIdFromElement());
    }

    private extractInformationFromElement() {
        const element = this._elementRef.nativeElement;
        if (element) {
            const [_, type, deskId] = element.id.split('-');
            this._resourceIdFromElement.set(type + deskId);
        }
    }
}
