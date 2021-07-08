import InspectionParam from "../../model/InspectionParam";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 角色状态类
 */
class InspectionParamState extends  BaseState {
  constructor()
  {
      super(new InspectionParam());
      let types=JSON.parse(localStorage.getItem("parameter"));
      if(types!=null) {
        this.parameterOptions.push(...types);
        this.workProcessOptions.push(...JSON.parse(localStorage.getItem("workProcess")));
        this.productOptions.push(...JSON.parse(localStorage.getItem("product")));
      }
  }
  filter={productId:0,workProcessId:0 };
  productOptions=[{id:0,name:'请选择'}];
  workProcessOptions=[{id:0,name:'请选择'}];
  parameterOptions=[{id:0,name:'请选择'}];
}
/**
 * action 基类
 */
export class InspectionParamActions extends  BaseActions{
}
/**
 * getters 基类
 */
class InspectionParamGetters extends  BaseGetters {
  productOptions=state=>state.productOptions;
  workProcessOptions=state=>state.workProcessOptions;
  parameterOptions=state=>state.parameterOptions;
}
/**
 * mutaions
 */
class InspectionParamMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new InspectionParamState(),
  getters:new InspectionParamGetters(),
  mutations:new InspectionParamMutations(),
  actions:new InspectionParamActions()
};


