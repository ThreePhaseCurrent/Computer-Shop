import {Product} from "../../entities/product";

export interface IProductState {
  products: Product[];
  selectedProduct: Product;
  isLoading: boolean;
  hasError: string;
  errorMessage: string;
}

export const initialProductState: {} = {
  products: null,
  selectedProduct: null,
  isLoading: false,
  hasError: false,
  errorMessage: null
}
