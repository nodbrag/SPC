
import WorkProcess from "../../model/WorkProcess";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 状态类
 */
class WorkProcessState extends  BaseState {
  constructor()
  {
    super(new WorkProcess());
    let types=JSON.parse(localStorage.getItem("defectItem"));
    if(types!=null)
      this.defectoptions.push(...types);
  }
  filter={ workProcessKeyword: '' }
  /**
   * 工序缺陷字典
   * @type {*[]}
   */
  defectoptions =[];
}
/**
 * action 基类
 */
export class WorkProcessActions extends  BaseActions{
}
/**
 * getters 基类
 */
class WorkProcessGetters extends  BaseGetters {
  defectoptions=state=>state.defectoptions;
}
/**
 * mutaions
 */
class WorkProcessMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new WorkProcessState(),
  getters:new WorkProcessGetters(),
  mutations:new WorkProcessMutations(),
  actions:new WorkProcessActions()
};


