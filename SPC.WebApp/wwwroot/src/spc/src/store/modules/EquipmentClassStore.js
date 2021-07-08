
import EquipmentClass from "../../model/EquipmentClass";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 状态类
 */
class EquipmentClassState extends  BaseState {
  constructor()
  {
    super(new EquipmentClass());
  }
  filter={ EquipmentClassName: '' }
}
/**
 * action 基类
 */
export class EquipmentClassActions extends  BaseActions{
}
/**
 * getters 基类
 */
class EquipmentClassGetters extends  BaseGetters {
}
/**
 * mutaions
 */
class EquipmentClassMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new EquipmentClassState(),
  getters:new EquipmentClassGetters(),
  mutations:new EquipmentClassMutations(),
  actions:new EquipmentClassActions()
};


