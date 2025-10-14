import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { BookableResource, ResourceStatus } from '@/features/floorplan/models/bookable-resource.model';
import { tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ReservableResourceService {
    private readonly _http = inject(HttpClient);
    // TODO: Definir a URL correta ao desenvolver o backend
    private readonly _baseUrl: string = 'https://api.example.com/resources';

    readonly resources = signal(new Map<string, BookableResource>());
    readonly allResources = computed(() => Array.from(this.resources().values()));

    readonly selectedId = signal<BookableResource['id'] | null>(null);
    readonly selectedResource = signal<BookableResource | null>(null);
    readonly loading = signal<boolean>(false);

    loadResourcesByFloorplanId(floorplanId: string, start: Date, end: Date) {
        this.loading.set(true);
        return this._http.get<BookableResource[]>(`${this._baseUrl}/reserve`, {
            params: {
                id: floorplanId,
                start: start.toISOString(),
                end: end.toISOString()
            }
        }).pipe(
            tap({
                next: (list) => {
                    this.resources.set(new Map<string, BookableResource>(list.map(r => [r.id, r])));
                    this.loading.set(false);
                },
                error: () => this.loading.set(false)
            })
        )
    }

    getResourceById(resourceId: string) {
        return computed(() => this.resources().get(resourceId) ?? null);
    }

    selectResource(resourceId: string) {
        this.selectedId.set(resourceId);
        const resource = this.resources().get(resourceId) ?? null;
        this.selectedResource.set(resource);
    }

    // TODO: Implementar a chamada real ao backend
    reserveResource(resourceId: string) {
        const resource = this.resources().get(resourceId) ?? null;
        if (resource) {
            this.updateStatus(resourceId, resource.status === 'available' ? 'occupied' : 'available');
        }
    }

    private updateStatus(resourceId: string, newStatus: ResourceStatus) {
        const resource = this.resources().get(resourceId);

        if (resource) {
            this.resources.update(currentMap => {
                const newMap = new Map(currentMap);
                newMap.set(resourceId, { ...resource, status: newStatus});
                return newMap;
            });
        }

        if (this.selectedId() === resourceId) {
            this.selectedResource.set(this.resources().get(resourceId) ?? null);
        }
    }
}
