// BaseViewModel
export class BaseViewModel {
  id: string;
  userId: string;

  constructor(id: string, userId: string) {
    this.id = id;
    this.userId = userId;
  }
}

// ProductViewModel
export class ProductViewModel extends BaseViewModel {
  name: string = "";
  description: string = "";
  costPrice: number;
  salePrice: number;
  quantityInStock: number;

  constructor(
    id: string,
    userId: string,
    name: string,
    description: string,
    costPrice: number,
    salePrice: number,
    quantityInStock: number
  ) {
    super(id, userId);
    this.name = name;
    this.description = description;
    this.costPrice = costPrice;
    this.salePrice = salePrice;
    this.quantityInStock = quantityInStock;
  }
}

// ClientViewModel
export class ClientViewModel extends BaseViewModel {
  name: string = "";
  address: string = "";
  cep: string = "";
  number: string = "";

  constructor(
    id: string,
    userId: string,
    name: string,
    address: string,
    cep: string,
    number: string
  ) {
    super(id, userId);
    this.name = name;
    this.address = address;
    this.cep = cep;
    this.number = number;
  }
}

// MonthlyProfitReportViewModel
export class MonthlyProfitReportViewModel extends BaseViewModel {
  month: number;
  totalProfit: number;

  constructor(id: string, userId: string, month: number, totalProfit: number) {
    super(id, userId);
    this.month = month;
    this.totalProfit = totalProfit;
  }
}

// SaleItemViewModel
export class SaleItemViewModel extends BaseViewModel {
  saleId: string;
  productId: string;
  quantity: number;
  price: number;

  constructor(
    id: string,
    userId: string,
    saleId: string,
    productId: string,
    quantity: number,
    price: number
  ) {
    super(id, userId);
    this.saleId = saleId;
    this.productId = productId;
    this.quantity = quantity;
    this.price = price;
  }
}

// SaleViewModel
export class SaleViewModel extends BaseViewModel {
  date: Date;
  totalValue: number;
  clientId: string;
  saleItems: SaleItemViewModel[];

  constructor(
    id: string,
    userId: string,
    date: Date,
    totalValue: number,
    clientId: string,
    saleItems: SaleItemViewModel[]
  ) {
    super(id, userId);
    this.date = date;
    this.totalValue = totalValue;
    this.clientId = clientId;
    this.saleItems = saleItems;
  }
}

// ResponseApiModel
export class ResponseApiModel<T extends BaseViewModel> {
  success: boolean = false;
  isInternalError: boolean = false;
  internalErrorMessage: string = "";
  statusCode: number = 0;
  errors: { property: string; message: string }[] = [];
  model?: T;

  
  constructor(
    
  ) {
  }
}