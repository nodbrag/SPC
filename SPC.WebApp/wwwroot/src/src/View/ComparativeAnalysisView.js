import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import BadPChart from '@/components/Chart/BadPChart.vue'
import OKPChart from '@/components/Chart/OKPChart.vue'
import ParetoChart from '@/components/Chart/ParetoChart.vue'
import {mapGetters,mapActions} from "vuex";


class ComparativeAnalysisMethods extends  BaseMethods{
  get MapMethods() {
    return {  ...mapActions('SpcAnalyseStore',['getContrastiveAnalysisData','getCompareContrastiveAnalysisData','showSearchDialog','closeSearchDialog'])}
  }
  search=function () {
    this.getContrastiveAnalysisData().then(()=>{
      this.closeSearchDialog();
      if(this.$refs.mychild1!=undefined) {
        this.$refs.mychild1.drawLine();
        this.$refs.mychild2.drawLine();
        this.$refs.mychild3.drawLine();
      }

    }).catch((error)=>{
      this.$message.warning({showClose: true, message:  error, duration: 2000});
    });;
  }
  searchCompare=function () {
    this.getCompareContrastiveAnalysisData().then(()=>{
      this.closeSearchDialog();
      if(this.$refs.mychild4!=undefined) {
        this.$refs.mychild4.drawLine();
        this.$refs.mychild5.drawLine();
        this.$refs.mychild6.drawLine();
      }

    }).catch((error)=>{
      this.$message.warning({showClose: true, message:  error, duration: 2000});
    });;
  }
}
class ComparativeAnalysisComputed extends  BaseComputed{
  get MapComputed() {
    return {  ...mapGetters('SpcAnalyseStore',['badChart','compareFilter','compareForm','badList','pSortChart','cbadChart','cbadList','cpSortChart'])
    ,...mapGetters('CommonDictionaryStore',['productOptions','equipmentOptions'])
    };
  }
}
let view={
  methods:new ComparativeAnalysisMethods(),
  computed:new ComparativeAnalysisComputed()
};

export default class ComparativeAnalysisView extends  BaseView {
  name='ComparativeAnalysisView';
  get store() {
    return "SpcAnalyseStore";
  }
  constructor(){
    super(view);
  }
  mounted=function () {
    if(this.filter.productId==undefined) {
      this.$message.warning({showClose: true, message:"请先进行SPC分析", duration: 2000});
    }else{
      this.pageChange(1);
      this.search();
    }
  };
  components={
    BadPChart,
    OKPChart,
    ParetoChart
  }
}
