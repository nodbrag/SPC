
import Equipment from "../../model/Equipment";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";

/**
 * 状态类
 */
class EquipmentState extends  BaseState {
  constructor()
  {
    super(new Equipment());
    let types=JSON.parse(localStorage.getItem("equipmentClass"));
    if(types!=null)
      this.equipmentClassOptions.push(...types);
  }
  filter={ equipmentKeyword: '' };
  /**
   * 设备分类
   * @type {*[]}
   */
  equipmentClassOptions =[];
  equipmentTypeOptions=[{ id:"检测类设备",name:"检测类设备"},{ id:"生产类设备",name:"生产类设备" },{ id:"其他设备",name:"其他设备" }];
}
/**
 * action 基类
 */
export class EquipmentActions extends  BaseActions{
}
/**
 * getters 基类
 */
class EquipmentGetters extends  BaseGetters {
  equipmentClassOptions=state=>state.equipmentClassOptions;
  equipmentTypeOptions=state=>state.equipmentTypeOptions;
}
/**
 * mutaions
 */
class EquipmentMutations extends BaseMutations {
}
export  default
{
  namespaced: true,
  state:new EquipmentState(),
  getters:new EquipmentGetters(),
  mutations:new EquipmentMutations(),
  actions:new EquipmentActions()
};


