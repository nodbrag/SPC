import BaseView, {BaseComputed, BaseMethods} from "./BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import {mapGetters} from "vuex";

class TaskMethods extends  BaseMethods{
  /**
   * 跳转到详情页方法
   */
  appearancejumpHtml = function (batchNo) {
    this.$router.push({
      path: '/appearance/detail',
      query: {
        id: batchNo
      }
    })
  };
}
class TaskComputed extends  BaseComputed{
  /**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('CommonDictionaryStore',['productOptions','equipmentOptions']) };
  }
}
let view={
  methods:new TaskMethods(),
  computed:new TaskComputed()
};

export default class TaskView extends  BaseView {
  name='TaskView';
  get store() {
    return "TaskStore";
  }
  constructor(){
    super(view);

  }
  mounted=function () {
    this.filter.workProcessName="视觉";
    this.pageChange(1);
    this.search();
  };
  components={
    TableToolBar,
    Pagination
  }
}
