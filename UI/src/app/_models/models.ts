
export interface APIResponse<T> {
    success: boolean;
    message: string;
    validationErrors: string[];
    data: T;
}

export interface Catalog {
  brands: Brand[];
}

export interface Price {
  min: number;
  max: number;
  currencyCode: string;
}


export class Product {
  id!: string;
  name: string;
  minFaceValue!: number;
  maxFaceValue!: number;
  count!: number;
  price!: Price;
  modifiedDate!: string;

  constructor() {
    this.name = "";
    this.id = "";
  }

}

export class OrderProduct {
  productId!: string;
  quantity!: number;
  value!: number;

  constructor( productId, quantity, value) {
    this.productId = productId;
    this.quantity = quantity;
    this.value = value;
  }

}

export interface Brand {
  name: string;
  countryCode: string;
  currencyCode: string;
  description: string;
  disclaimer: any;
  redemptionInstructions: string;
  terms: string;
  logoUrl: string;
  modifiedDate: string;
  products: Product[];
}

export interface ShoppingItem {
  id: string;
  quantity: number;
  price: number;
  product: Product;
}


export class Order {
    requestID!: string;
    accountId!: string;
    products!: OrderProduct[];
    constructor() {
           this.products = OrderProduct[10];
        }
      }

export class Accounts {
  accounts!: Account[];
}
export interface Account {
  id: number;
  currency: string;
  balance: number;
  isActive: boolean;
}

