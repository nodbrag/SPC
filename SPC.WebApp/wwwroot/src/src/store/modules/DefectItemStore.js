
import DefectItem from "../../model/DefectItem";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 状态类
 */
class DefectItemState extends  BaseState {
  constructor()
  {
    super(new DefectItem());
  }
  filter={ defectItemKeyword: '' }
}
/**
 * action 基类
 */
export class DefectItemActions extends  BaseActions{
}
/**
 * getters 基类
 */
class DefectItemGetters extends  BaseGetters {
}
/**
 * mutaions
 */
class DefectItemMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new DefectItemState(),
  getters:new DefectItemGetters(),
  mutations:new DefectItemMutations(),
  actions:new DefectItemActions()
};


