import {initialProductState} from "../states/product.states";
import {ProductAction, ProductActionTypes} from "../actions/product.actions";
import {IProductState} from "../states/product.states";

export const productReducers = (
  state = initialProductState,
  action: ProductAction): IProductState => {
    switch(action.type){
      case ProductActionTypes.ADD_TO_CART: {
        return {
          ...state,
          products: null,
          selectedProduct: null,
          isLoading: null,
          hasError: null,
          errorMessage: null
        }
      }
    }
  }
