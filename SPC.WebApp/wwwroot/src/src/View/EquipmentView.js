import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import {mapGetters} from "vuex";

class EquipmentMethods extends  BaseMethods{
}
class EquipmentComputed extends  BaseComputed{
  /**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('EquipmentStore',['equipmentClassOptions','equipmentTypeOptions'])};
  }
}
let view={
  methods:new EquipmentMethods(),
  computed:new EquipmentComputed()
};

export default class EquipmentView extends  BaseView {
  name='EquipmentView';
  get store() {
    return "EquipmentStore";
  }
  constructor(){
    super(view);
  }
  mounted=function () {
    this.pageChange(1);
    this.search();
  }
  components={
    TableToolBar,
    Pagination
  }
}
