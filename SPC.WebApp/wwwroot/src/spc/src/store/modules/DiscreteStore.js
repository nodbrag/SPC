
import Discrete from "../../model/Discrete";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 角色状态类
 */
class DiscreteState extends  BaseState {
  constructor()
  {
      super(new Discrete());
  }
  filter={ DiscreteName: '' }
}
/**
 * action 基类
 */
export class DiscreteActions extends  BaseActions{
}
/**
 * getters 基类
 */
class DiscreteGetters extends  BaseGetters {
}
/**
 * mutaions
 */
class DiscreteMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new DiscreteState(),
  getters:new DiscreteGetters(),
  mutations:new DiscreteMutations(),
  actions:new DiscreteActions()
};


