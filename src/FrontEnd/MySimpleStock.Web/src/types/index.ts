// BaseViewModel
export class BaseModel {
  id: string = "";
  userId: string = "";
}

// ProductViewModel
export class ProductModel extends BaseModel {
  name: string = "";
  description: string = "";
  costPrice: number = 0;
  salePrice: number = 0;
  creationDate: Date = new Date();
  quantityInStock: number = 0;
}

// ClientViewModel
export class ClientModel extends BaseModel {
  name: string = "";
  address: string = "";
  cep: string = "";
  number: string = "";
}

// MonthlyProfitReportViewModel
export class MonthlyProfitReportModel extends BaseModel {
  month: number = 0;
  totalProfit: number = 0;
}

// SaleItemViewModel
export class SaleItemModel extends BaseModel {
  saleId: string = "";
  productId: string = "";
  quantity: number = 0;
  price: number = 0;
  product: ProductModel = new ProductModel();
}

// SaleViewModel
export class SaleModel extends BaseModel {
  date: Date = new Date();
  totalValue: number = 0;
  clientId: string = "";
  creationDate: Date = new Date();
  client: ClientModel = new ClientModel();
  saleItems: SaleItemModel[] = [];
}

// ResponseApiModel
export class ResponseApiModel<T extends BaseModel> {
  success: boolean = false;
  isInternalError: boolean = false;
  internalErrorMessage: string = "";
  statusCode: number = 0;
  errors: { property: string; message: string }[] = [];
  model?: T;
}
