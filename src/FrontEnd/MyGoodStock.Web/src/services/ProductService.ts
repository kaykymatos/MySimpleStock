import { ProductViewModel } from "../types";
import { BaseService } from "./BaseService";

export class ProductService extends BaseService<ProductViewModel>{
    
    constructor() {
        super("v1/products");
        
    }
}