
import Product from "../../model/Product";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 状态类
 */
class ProductState extends  BaseState {
  constructor()
  {
    super(new Product());
  }
  filter={ productKeyword: '' }
}
/**
 * action 基类
 */
export class ProductActions extends  BaseActions{
}
/**
 * getters 基类
 */
class ProductGetters extends  BaseGetters {
}
/**
 * mutaions
 */
class ProductMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new ProductState(),
  getters:new ProductGetters(),
  mutations:new ProductMutations(),
  actions:new ProductActions()
};


