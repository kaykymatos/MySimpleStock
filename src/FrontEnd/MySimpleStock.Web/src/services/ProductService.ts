import { ProductModel } from "../types";
import { BaseService } from "./BaseService";

export class ProductService extends BaseService<ProductModel>{
    
    constructor() {
        super("v1/products");
        
    }
}