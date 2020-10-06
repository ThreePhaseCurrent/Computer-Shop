import { Action } from '@ngrx/store';
import { Product } from '../../../shared/models/product';

export enum ProductActionTypes {
    ADD_TO_CART = '[Product] Add to cart',
    REMOVE_FROM_CART = '[Product] Remove from cart',
    LOAD_ITEMS = '[Products] Load items from server',
    LOAD_ITEMS_SUCCESS = '[Products] Load items success'
}

export class AddToCart implements Action {
    readonly type = ProductActionTypes.ADD_TO_CART;
    constructor(productId: number) {}
}

export class RemoveFromCart implements Action {
    readonly type = ProductActionTypes.REMOVE_FROM_CART;
    constructor(productId: number) {}
}

export class LoadItems implements Action {
    readonly type = ProductActionTypes.LOAD_ITEMS;
    constructor() {}
}

export class LoadItemsSuccess implements Action {
    readonly type = ProductActionTypes.LOAD_ITEMS_SUCCESS;
    constructor() {}
}

export type ProductAction = 
    | AddToCart
    | RemoveFromCart
    | LoadItems
    | LoadItemsSuccess;