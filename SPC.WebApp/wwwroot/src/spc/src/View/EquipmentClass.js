import { mapGetters } from "vuex";
import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
/**
 * UI 层方法
 */
class EquipmentClassMethods extends  BaseMethods{
  /**
   * 用户类型
   * @param row
   * @returns {string}
   */
  formattype=function (row) {

    let rolelist= JSON.parse(window.localStorage.getItem("role"));
    if(rolelist!=null) {
      let role = rolelist.find((obj) => row.roleID.find((o)=>o==obj.id));
      if (role != undefined)
        return role.name;
      else
        return "超级管理员";
    }
  };
  /**
   * 返回 vuex 混入的方法
   * @returns {{}}
   * @constructor
   */
  get MapMethods() {
    return {};
  }
}
class EquipmentClassComputed extends  BaseComputed{
  /**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('EquipmentClassStore',['typeoptions'])};
  }

}
let view={
  methods:new EquipmentClassMethods(),
  computed:new EquipmentClassComputed()
};

export default class EquipmentClassView extends  BaseView {
  name='EquipmentClassView';
  get store() {
    return "EquipmentClassStore"
  }
  constructor(){
    super(view);
  }
  mounted=function (){
    this.pageChange(1);
    this.search();
  }
  components={
    TableToolBar,
    Pagination
  }
}
