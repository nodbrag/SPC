import BaseView, {BaseComputed, BaseMethods} from "./BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import importListModal from '@/pages/Dimension/List/importModal.vue'
import {mapActions, mapGetters} from "vuex";

class DimensionMethods extends  BaseMethods{
  get MapMethods() {
    return {  ...mapActions('TaskStore',['uploadExcel','importDimensionData'])}
  }

  impartData=function () {
    this.$refs.addForm.validate((valid) => {
      if (valid) {
        this.importDimensionData().then(data => {
          this.$refs['addForm'].resetFields();
          this.$message.success({showClose: true, message: '导入成功', duration: 2000});
        }).catch((error) => {
          this.$message.error({showClose: true, message: '导入失败:' + error, duration: 2000});
        })
      }
    });
  };
  beforeUpload=function (file) {
    const isText = file.type === 'application/vnd.ms-excel'
    const isTextComputer = file.type === 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
    return (isText | isTextComputer)
  };
  handleExceed=function () {
    this.$message.warning(`当前限制选择 1 个文件，请删除后继续上传`)
  };
  uploadFile=function (item) {
    //console.log(item)
    const fileObj = item.file;
    // FormData 对象
    const form = new FormData();
    // 文件对象
    form.append('file', fileObj);
    form.append('comId', this.comId);
    //alert(1);
    this.uploadExcel(form);
    //console.log(JSON.stringify(form))
  }
  /**
   * 跳转到详情页方法
   */
  dimensionDetailjumpHtml = function (batchNo) {

    this.$router.push({
      path: '/dimension/detail',
      query: {
        id: batchNo
      }
    })
  };
  /**
   * 跳转到汇总方法
   */
  dimensionSummaryjumpHtml = function (batchNo) {
    this.$router.push({
      path: '/dimension/summary',
      query: {
        id: batchNo
      }
    })
  };
  Type = function () {
  let maxHeight = window.innerHeight-220;
  };
}

class DimensionComputed extends  BaseComputed{
  /**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('CommonDictionaryStore',['equipmentOptions','productOptions'])};
  }
}
let view={
  methods:new DimensionMethods(),
  computed:new DimensionComputed()
};

export default class DimensionView extends  BaseView {
  name='DimensionView';
  get store() {
    return "TaskStore";
  }
  constructor(){
    super(view);

  }
  mounted=function () {
    this.filter.workProcessName="尺寸";
    this.pageChange(1);
    this.search();
    this.Type();
  };
  components={
    TableToolBar,
    Pagination,
    importListModal
  }
}
