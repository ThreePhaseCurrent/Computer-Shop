import {ProductCategory} from "./productCategory";
import {Manufacturer} from "./manufacturer";
import {Discount} from "./discount";

export class Product {
  productId: number;
  productImage: string;
  name: string;
  description: string;
  price: number;
  rate: number;
  shortDescription: string;

  category: ProductCategory;
  manufacturer: Manufacturer;
  discount: Discount;
}
