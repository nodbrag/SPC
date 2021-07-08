import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import {mapGetters} from "vuex";

class ParameterMethods extends  BaseMethods{

}
class ParameterComputed extends  BaseComputed{
/**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('ParameterStore',['parameterDataTypeOptions','parameterValueTypeOptions'])};
  }
}
let view={
  methods:new ParameterMethods(),
  computed:new ParameterComputed()
};

export default class ParameterView extends  BaseView {
  name='ParameterView';
  get store() {
    return "ParameterStore";
  }
  constructor(){
    super(view);
  }
  mounted=function () {
    this.pageChange(1);
    this.search();
  };
  components={
    TableToolBar,
    Pagination
  }
}
