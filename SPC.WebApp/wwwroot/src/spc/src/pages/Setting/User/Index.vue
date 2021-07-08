<template>
  <el-row class="warp">
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
          <div class="box_search">
            <el-form ref="form" :model="filter">
              <el-input v-model="filter.Keyword" @keyup.enter.native="search" size="mini" placeholder="用户名/真实姓名"></el-input>
              <el-button type="primary" icon="el-icon-search" size="mini" @click="search" >搜索</el-button>
              <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right" size="mini" @click="showAddDialog" >添加</el-button>
            </el-form>
          </div>
      </div>
      <!--列表-->
      <el-table :data="datalist" highlight-current-row @selection-change="selectInfos" stripe
                style="width: 100%;">
        <el-table-column type="index" width="60">
        </el-table-column>
        <el-table-column prop="userName" label="姓名"  sortable>
        </el-table-column>
        <el-table-column prop="userCode" label="登录名" sortable>
        </el-table-column>
        <el-table-column prop="roleID" label="用户角色"   :formatter="formattype" sortable>
        </el-table-column>
        <el-table-column prop="eMail" label="电子邮箱"  sortable>
        </el-table-column>
        <el-table-column prop="telephone" label="固定电话"  sortable>
        </el-table-column>
        <el-table-column prop="mobilePhone" label="移动电话"  sortable>
        </el-table-column>
        <el-table-column label="操作" width="180">
          <template slot-scope="scope">
            <el-button size="small"  v-if="scope.row.userName!='超级管理员'"  @click="showEditDialog(scope.row)">编辑</el-button>
            <el-button type="danger"  v-if="scope.row.userName!='超级管理员'"   @click="del(scope.row.userID)" size="small">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!--工具条-->
      <el-col :span="24" class="toolbar">
        <Pagination
          @handleCurrentChange="handleCurrentChange"
          @handleSizeChange="maxResultCountSelect"
          :page-size="maxResultCount"
          :page-sizes="pageSelectList"
          :total="totalCount">
        </Pagination>
      </el-col>
      <!--新增界面-->
      <el-dialog  :visible.sync ="addFormVisible"  :before-close="closeAddDialog">
        <div slot="title">添加用户</div>
        <el-form :model="addForm" label-width="120px" :rules="editFormRules" ref="addForm">
          <el-form-item label="用户名:" prop="userCode">
            <el-input v-model="addForm.userCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="真实姓名:" prop="userName">
            <el-input v-model="addForm.userName" auto-complete="off"></el-input>
          </el-form-item>

          <el-form-item label="用户角色:" prop="roleID">
            <el-select v-model="addForm.roleID" multiple placeholder="请选择">
              <el-option
                v-for="item in typeoptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="电子邮件:" prop="eMail">
            <el-input v-model="addForm.eMail" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="固定电话:" prop="telephone">
            <el-input v-model="addForm.telephone" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="移动电话:" prop="mobilePhone">
            <el-input v-model="addForm.mobilePhone" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeAddDialog">取消</el-button>
          <el-button type="primary" @click.native="add" :loading="loading">保存</el-button>
        </div>
      </el-dialog>

      <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
        <div slot="title">编辑用户</div>
        <el-form :model="editForm" label-width="120px" :rules="editFormRules" ref="editForm">
          <el-form-item label="用户名:" prop="userCode">
            <el-input v-model="editForm.userCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="真实姓名:" prop="userName">
            <el-input v-model="editForm.userName" auto-complete="off"></el-input>
          </el-form-item>

          <el-form-item label="用户角色:" prop="roleID">
            <el-select v-model="editForm.roleID" multiple  placeholder="请选择">
              <el-option
                v-for="item in typeoptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>

          <el-form-item label="电子邮件:" prop="eMail">
            <el-input v-model="editForm.eMail" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="固定电话:" prop="telephone">
            <el-input v-model="editForm.telephone" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="移动电话:" prop="mobilePhone">
            <el-input v-model="editForm.mobilePhone" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeEditDialog">取消</el-button>
          <el-button type="primary" :loading="loading" @click.native="edit">保存</el-button>
        </div>
      </el-dialog>
    </el-col>
  </el-row>
</template>
<script>
import UserView from '../../../View/UserView'
export default new UserView();
</script>
<style lang="stylus" scope>
@import '../../../common/common.stylus'
</style>
