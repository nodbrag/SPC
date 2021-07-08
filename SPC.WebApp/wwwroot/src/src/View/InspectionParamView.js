import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import {mapGetters} from "vuex";

class InspectionParamMethods extends  BaseMethods{
}
class InspectionParamComputed extends  BaseComputed{
/**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('InspectionParamStore',['productOptions','workProcessOptions','parameterOptions'])};
  }
}
let view={
  methods:new InspectionParamMethods(),
  computed:new InspectionParamComputed()
};

export default class InspectionParamView extends  BaseView {
  name='InspectionParamView';
  get store() {
    return "InspectionParamStore";
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
