
import Role from "../../model/Role";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 角色状态类
 */
class RoleState extends  BaseState {
  constructor()
  {
      super(new Role());
  }
  filter={ RoleName: '' }
}
/**
 * action 基类
 */
export class RoleActions extends  BaseActions{
}
/**
 * getters 基类
 */
class RoleGetters extends  BaseGetters {
}
/**
 * mutaions
 */
class RoleMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new RoleState(),
  getters:new RoleGetters(),
  mutations:new RoleMutations(),
  actions:new RoleActions()
};


