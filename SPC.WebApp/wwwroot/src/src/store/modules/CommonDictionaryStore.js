import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";
import MutationTypes from "@/store/MutationTypes";
/**
 * 公共字典状态类
 */
class CommonDictionaryState extends  BaseState {
  constructor()
  {
    super({});
    let product= localStorage.getItem("product");
    if(product!=null&&product!=undefined) {
      this.productOptions.push(...JSON.parse(localStorage.getItem("product")));
      this.equipmentOptions.push(...JSON.parse(localStorage.getItem("equipment")));
    }
  }
  /**
   * 产品字典
   * @type {Array}
   */
  productOptions=[{id:0,name:'请选择'}];
  /**
   * 设备字典
   * @type {Array}
   */
  equipmentOptions=[{id:0,name:'请选择'}];
  /**
   * 菜单信息
   * @type {{}}
   */
  menuAll=JSON.parse(localStorage.getItem("menu"));

}
/**
 * action 基类
 */
export class CommonDictionaryActions extends  BaseActions{
}
/**
 * getters 基类
 */
class CommonDictionaryGetters extends  BaseGetters {
  menuAll= state=>state.menuAll;
  equipmentOptions=state=>state.equipmentOptions;
  productOptions=state=>state.productOptions;
}
/**
 * mutaions
 */
class CommonDictionaryMutations extends BaseMutations {
  [MutationTypes.SET_MENU]=(state, {menus})=>{
    state.menuAll = menus;
  };
  [MutationTypes.EquipmentOptions]=(state, {val})=>{
    state.equipmentOptions.length=0;
    state.equipmentOptions.push(...val);
  };
  [MutationTypes.ProductOptions]=(state, {val})=>{
    state.productOptions.length=0;
    state.productOptions.push(...val);
  };
}
export  default
{
  namespaced: true,
  state:new CommonDictionaryState(),
  getters:new CommonDictionaryGetters(),
  mutations:new CommonDictionaryMutations(),
  actions:new CommonDictionaryActions()
};
