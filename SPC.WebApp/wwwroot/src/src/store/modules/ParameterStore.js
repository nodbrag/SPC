
import Parameter from "../../model/Parameter";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 角色状态类
 */
class ParameterState extends  BaseState {
  constructor()
  {
      super(new Parameter());
  }
  filter={parameterKeyword:''};
  /**
   * 数据类型
   * @type {*[]}
   */
  parameterDataTypeOptions=[{ id:"int",name:"整形"},{ id:"string",name:"字符串" }];
  parameterValueTypeOptions=[{ id:"int",name:"整形"},{ id:"string",name:"字符串" }];
}
/**
 * action 基类
 */
export class ParameterActions extends  BaseActions{
}
/**
 * getters 基类
 */
class ParameterGetters extends  BaseGetters {
  parameterValueTypeOptions=state=>state.parameterValueTypeOptions;
  parameterDataTypeOptions=state=>state.parameterDataTypeOptions;
}
/**
 * mutaions
 */
class ParameterMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new ParameterState(),
  getters:new ParameterGetters(),
  mutations:new ParameterMutations(),
  actions:new ParameterActions()
};


