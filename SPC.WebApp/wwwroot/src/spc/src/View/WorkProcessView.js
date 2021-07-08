import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import {mapGetters} from "vuex";

class WorkProcessMethods extends  BaseMethods{
  defectoptions
}
class WorkProcessComputed extends  BaseComputed{
  /**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('WorkProcessStore',['defectoptions'])};
  }
}
let view={
  methods:new WorkProcessMethods(),
  computed:new WorkProcessComputed()
};

export default class WorkProcessView extends  BaseView {
  name='WorkProcessView';
  get store() {
    return "WorkProcessStore";
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
